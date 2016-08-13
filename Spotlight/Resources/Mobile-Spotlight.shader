Shader "Mobile/Custom/Spotlight" {
  Properties {
    [NoScaleOffset][PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
    _BaseColor ("Base Color", Color) = (0,0,0,1)
		_Color ("Tint", Color) = (1,1,1,1)
  }

  SubShader {
    Tags {
      "Queue"="Transparent"
      "RenderType"="Transparent"
      "IgnoreProjector"="True"
    }

    Cull Off
    Lighting Off
    ZTest Off
    ZWrite Off
    Fog { Mode Off }
    Blend One OneMinusSrcAlpha

    Pass {
      CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        struct appdata_t {
          float4 vertex   : POSITION;
          float2 texcoord : TEXCOORD0;
        };

        struct v2f {
          float4 vertex   : SV_POSITION;
          half2 texcoord  : TEXCOORD0;
        };

        fixed4 _BaseColor;
  			fixed4 _Color;

        v2f vert(appdata_t IN) {
          v2f OUT;
          OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
          OUT.texcoord = IN.texcoord;
          return OUT;
        }

        sampler2D _MainTex;

        fixed4 frag(v2f IN) : SV_Target {
          fixed4 texColor = tex2D(_MainTex, IN.texcoord);
          fixed4 c = _BaseColor * _Color;
          c.a *= texColor.r;
          return c;
        }
      ENDCG
    }
  }

  Fallback "Mobile/Particles/Alpha Blended"
}
