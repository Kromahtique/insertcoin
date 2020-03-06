Shader "Custom/GameRenderingShader" {
	Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { 
			"Queue"="Transparent"
			"PreviewType"="Plane"
		}

		Pass {
			ZWrite Off
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			struct appdata {
				float vertex : POSITION;
				float uv : TEXCOORD0;
				half4 color: COLOR;
			};

			struct v2f {
				float vertex : SV_POSITION;
				float2 uv: TEXCOORD0;
				half4 color: COLOR;
			};

			v2f vert(appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				o.uv = v.uv;
				o.screenuv = ((o.vertex.xy / o.vertex.w) + 1) * 0.5;
				o.color = v.color;
				return o;
			}

			sampler2D _MainTex;
			uniform sampler2D _GameCameraTexture;

			float4 frag(v2f i) : SV_Target{
				return tex2D(_GameCameraTexture, i.screenuv) * i.color;
			}
			ENDCG
		}
	}
}
