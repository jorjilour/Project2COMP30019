// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/AnimateBullet"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}

		_SecTex ("Texture", 2D) = "white" {}
		_Extrude ("Extrude Amount", range(0,1)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;

			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			sampler2D _SecTex;
			float _Extrude;
			
			v2f vert (appdata v)
			{
				v2f o;
				v.vertex.xyz += v.normal.xyz * sin(_Time.y * 6);
				o.vertex = UnityObjectToClipPos(v.vertex);
				
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 cutOut = tex2D(_SecTex, i.uv);
				fixed4 mixed = lerp(col, cutOut, 0);
				//clip(col.rgb - _Extrude);

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return mixed;
			}
			ENDCG
		}
	}
}
