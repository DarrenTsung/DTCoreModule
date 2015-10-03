Shader "Sprites/Default-BurnShader"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_DissolveMap ("Dissolve Map", 2D) = "white" {}
		_DissolveAmount ("Dissolve Amount", Float) = 0
		_BurnRampTex ("Burn Ramp Texture", 2D) = "white" {}
		_BurnRampScale ("Burn Ramp Scale", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;
			
			sampler2D _DissolveMap;
			float _DissolveAmount;

			sampler2D _BurnRampTex;
			float _BurnRampScale;
			
			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				
				fixed4 dissolveC = tex2D(_DissolveMap, IN.texcoord);
				// texture should be grayscale so any channel should work, but we'll default to using red right now
				c.a *= step(_DissolveAmount, dissolveC.r);
				
				float distanceToDissolve = abs(_DissolveAmount - dissolveC.r);
				float burnAmount = clamp(distanceToDissolve, 0.0f, _BurnRampScale);
				fixed4 burnC = tex2D(_BurnRampTex, half2(1.0f - (burnAmount / _BurnRampScale), 0.5f));
				c.rgb = lerp(c.rgb, burnC, step(distanceToDissolve, burnAmount));
				
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}
