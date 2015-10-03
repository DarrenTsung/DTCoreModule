Shader "Sprites/Default-BackgroundArt"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_FogSubtractedColor ("Fog Subtracted Color", Color) = (0, 0, 0, 1)
		_MaxDepth ("Max Depth", float) = 100.0
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
				float fogDepth  : TEXCOORD1;
			};
			
			fixed4 _Color;
			fixed4 _FogSubtractedColor;
			float _MaxDepth;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				float4 worldPos = mul(_Object2World, IN.vertex);
				float depth = min(1.0f, worldPos.z / _MaxDepth);
				
				float2 parallaxTranslate = _WorldSpaceCameraPos.xy * depth;
				
				/*worldPos.xy += parallaxTranslate.xy;
				float4 translatedVertex = mul(_World2Object, worldPos);*/
				OUT.fogDepth = depth;
				
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{
				float2 uv = IN.texcoord;
				fixed4 c = tex2D(_MainTex, uv) * IN.color;
				c -= _FogSubtractedColor * IN.fogDepth;
				
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
}
