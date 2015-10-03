Shader "Sprites/Default-PulseShader"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		
		_Pulsing ("Pulsing", Int) = 0
		_PulseSpeed ("PulseSpeed", Float) = 0.4
		
		_PulseColor ("Pulse Color", Color) = (1, 1, 1, 1)
		_PulseColorPercentLerp ("Pulse Color Percent Lerp", Float) = 0.5
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
			
		 	int _Pulsing;
			float _PulseSpeed;
			
			fixed4 _PulseColor;
			float _PulseColorPercentLerp;
			
			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;

				return color;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
				const float PI = 3.14159;
				
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				float pulseValue = ((sin(_Time[1] * 2.0f * PI / _PulseSpeed) / 2.0f) + 0.5f);
				c.rgb = lerp(c.rgb, _PulseColor.rgb, _Pulsing * pulseValue * _PulseColorPercentLerp);
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}
