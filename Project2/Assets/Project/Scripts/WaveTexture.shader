Shader "Custom/WaveTexture" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		
		_WaveFirst ("Wave First (dir, steepness level, wave length", Vector) = (0, 1, 0.1, 10)
		_WaveSec ("Wave Second", Vector) = (1, 0, 0.15, 20)
		_WaveThird ("Wave Third", Vector) = (1, 1, 0.2, 10)
	
		[NoScaleOffset] _Flow ("Flow map", 2D) = "black" {}
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard alpha fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		struct Input {
			float2 uv_MainTex;
		};


		sampler2D _MainTex;
		sampler2D _Flow;

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		// float _Steep;
		// float _Wave;
		// float2 _Direction;

		float4 _WaveFirst;
		float4 _WaveSec;
		float4 _WaveThird;

		

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		float3 WaveCreator (float4 wave, float3 finalXYZ, 
							inout float3 tangent, inout float3 binormal) {
			
			float steepness = wave.z;
			float wavelength = wave.w;

			float trans = 2 * UNITY_PI / wavelength;
			float speed = sqrt(5.5/trans);
			float2 dir = normalize(wave.xy);
			float shape = trans * (dot(dir, finalXYZ.xz) - speed * _Time.y);		
			float amp = steepness / trans;

			tangent += float3(
				-dir.x * dir.x * steepness * sin(shape),
				dir.x * steepness * cos(shape),
				dir.x * dir.y * steepness * sin(shape)
			);

			binormal += float3(
				-dir.x * dir.y * steepness * sin(shape),
				dir.y * steepness * cos(shape),
				-dir.y * dir.y * steepness * sin(shape)
			);

			return float3(
				dir.x * amp * cos(shape),
				amp * sin(shape),
				dir.y * amp * cos(shape)
			);
		}

		void vert(inout appdata_full v) {

			float3 init = v.vertex.xyz;
			float3 tangent = float3(1,0,0);
			float3 binormal = float3(0,0,1);
			float3 finalXYZ = init;

			// finalXYZ += WaveCreator(_WaveFirst, init, tangent, binormal);
			// finalXYZ += WaveCreator(_WaveSec, init, tangent, binormal);
			// finalXYZ += WaveCreator(_WaveThird, init, tangent, binormal);
			// float3 normal = normalize(cross(binormal, tangent));

			v.vertex.xyz = finalXYZ;
			//v.normal = normal;
		}

		float3 flowUvw (float2 uv, float2 flowV, float time, bool flowSec) {
			float phaseOffset = flowSec ? 0.5 : 0;
			float prog = frac(time + phaseOffset);
			float3 uvw;
			uvw.xy = uv - flowV * prog + phaseOffset;
			uvw.z = 1 - abs(1 - 2 * prog);
			return uvw;
		}
		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			float2 flowV = tex2D(_Flow, IN.uv_MainTex).rg * 2 - 1;
			float noise = tex2D(_Flow, IN.uv_MainTex).a;
			float time = _Time.y + noise;
			
			float3 uvwA = flowUvw(IN.uv_MainTex, flowV, time, false); 
			float3 uvwB = flowUvw(IN.uv_MainTex, flowV, time, true); 

			fixed4 texA = tex2D(_MainTex, uvwA.xy) * uvwA.z;
			fixed4 texB = tex2D(_MainTex, uvwB.xy) * uvwB.z;

			fixed4 c = (texA + texB) * _Color;

			// Albedo comes from a texture tinted by color
			o.Albedo = c.rgb;
			
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
