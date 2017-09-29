// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "UI/Custom/Circle"
{
	Properties
	{
		_Color ("Tint", Color) = (1,1,1,1)

		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15

		// Circle Input
		_Radius ("Radius", Range(0, 0.5)) = 0.5
		_Width ("Width", Range(0, 0.5)) = 0.01
		_SegmentLength ("Segment Length", Range(0, 1)) = 1.0
		_AngleOffset ("Angle Offset", Range(0, 1)) = 0.0

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
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

		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]

		Pass
		{
			Name "Default"
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile __ UNITY_UI_ALPHACLIP

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD1;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			fixed4 _Color;
			float4 _ClipRect;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
				OUT.worldPosition = IN.vertex;
				OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

				OUT.texcoord = IN.texcoord;

				OUT.color = IN.color * _Color;
				return OUT;
			}

			float _Radius;
			float _Width;
			float _SegmentLength;
			float _AngleOffset;

			fixed4 frag(v2f IN) : SV_Target
			{
				half4 color = IN.color;

				color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);

				const float ALIAS = 0.003f;

				// check if inside circle
				float2 circlecoord = IN.texcoord - float2(0.5, 0.5);
				// 0 if outside _Radius, 1 otherwise
				float coordSqrdLength =  dot(circlecoord, circlecoord);
				color.a *= smoothstep(coordSqrdLength, coordSqrdLength + ALIAS, pow(_Radius, 2));
				// 0 if inside (_Radius - _Width), 1 otherwise
				float inner = pow(max(0.0, _Radius - _Width), 2);
				color.a *= smoothstep(inner, inner + ALIAS, coordSqrdLength);

				// Circle Segment Logic
				const float PI = 3.14159265359;
				float x = (atan2(circlecoord.y, circlecoord.x) - PI/2.0);
				float y = 2.0*PI;
				float angle = (x - y * floor(x/y))/(2.0*PI);

				// center angle based on segment length
				angle += _SegmentLength / 2.0f;

				angle = (angle + _AngleOffset) % 1.0f;

				// 0 if outside angle, 1 otherwise
				color.a *= step(angle, _SegmentLength);

				#ifdef UNITY_UI_ALPHACLIP
				clip (color.a - 0.001);
				#endif

				return color;
			}
		ENDCG
		}
	}
}
