Shader "Particles/Shield Scroll Alpha Blended distort(white texture)"
{
Properties
{
	_MainTex ("Particle Texture", 2D) = "white" {}
	_Dist ("dist (r) add (g) ", 2D) = "white" {}
	//_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
	_Multiply ("Multiply", Range(0.1,8.0)) = 1.0
	_DistortionAmount ("DistAmount", Float) = 1.0
	_Scrolltime ("ScrollTime", Float) = 1.0
	_Offset ("ShieldActive", Range(0.0,1.0)) = 1.0
	_Scale ("ShieldScale", Range(0.0,1.0)) = 1.0
	
}

Category
{
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
	Cull Off Lighting Off ZWrite Off Fog { Mode Off }
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _Dist;
			fixed4 _TintColor;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 texcoord2 : TEXCOORD1;
			};

			struct v2f {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 texcoord2 : TEXCOORD2;

			};
			float _InvFade, _DistortionAmount, _Scrolltime, _Offset;
			float4 _MainTex_ST;
			float4 _Dist_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				o.texcoord2 = TRANSFORM_TEX(v.texcoord,_Dist) + _Time.x * _Scrolltime ;
				return o;
			}


			
			float _Multiply; 
			
			fixed4 frag (v2f i) : COLOR
			{

				
				_Multiply *= i.color.a;
				fixed4 dist = tex2D(_Dist, i.texcoord2);
				fixed prev = tex2D(_MainTex, i.texcoord + dist.r * _DistortionAmount).r;
				fixed pulse = dist.g * prev;
				prev += pulse;
				
				prev *= pow(saturate( i.texcoord.y + _Offset - 0.5), 8) ;
				
				//return lerp(half4(i.color.rgb , 0), i.color + prev * i.color.a * _Multiply, prev * i.color.a);
				return lerp(half4(i.color.rgb , 0), i.color + prev * _Multiply, prev * i.color.a);
			}
			ENDCG 
		}
	}
}
}
