//UNITY_SHADER_NO_UPGRADE

Shader "Unlit/WaveShader"
{
	Properties
	{
		_PointLightColor("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition("Point Light Position", Vector) = (0.0, 0.0, 0.0)
	}
		SubShader
	{
		Pass
	{
		Cull Off

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"
		uniform float3 _PointLightColor;
	uniform float3 _PointLightPosition;

	//uniform sampler2D _MainTex;	

	struct vertIn
	{
		float4 vertex : POSITION;
		//float4 normal : NORMAL;
		float4 color : COLOR;
	};

	struct vertOut
	{
		float4 vertex : SV_POSITION;
		float4 color : COLOR;
	};

	// Implementation of the vertex shader
	vertOut vert(vertIn v)
	{
		vertOut o;

		float4 displacement = float4(0.0f, pow(sin(v.vertex.x + v.vertex.z + _Time.y * 0.7f), 2) * 0.9f, 0.0f, 0.0f);

		v.vertex += displacement;

		o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		
		o.color = v.color;
		return o;
	}

	// Implementation of the fragment shader
	fixed4 frag(vertOut v) : SV_Target
	{


		return v.color;
	}
		ENDCG
	}
	}
}