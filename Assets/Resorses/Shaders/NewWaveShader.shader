Shader "Custom/WaterWaveTessellationShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WaveSpeed("Wave Speed", Float) = 1.0
        _WaveHeight("Wave Height", Float) = 0.1
        _WaveFrequency("Wave Frequency", Float) = 1.0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 300

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 5.0
                #pragma require tessellation hs

                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float _WaveSpeed;
                float _WaveHeight;
                float _WaveFrequency;

                // Vertex shader
                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                // Hull shader (Tessellation Control Shader)
                // Define tessellation factors
                [maxtessfactor(64.0)]
                [domain("tri")]
                v2f hull(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                // Domain shader (Tessellation Evaluation Shader)
                [domain("tri")]
                v2f domain(appdata_t v, float3 barycentric : SV_DomainLocation)
                {
                    v2f o;
                    float3 pos = barycentric.x * v.vertex + barycentric.y * v.vertex + barycentric.z * v.vertex;
                    float wave = sin(_Time.y * _WaveSpeed + pos.x * _WaveFrequency) * _WaveHeight;
                    pos.y += wave;
                    o.vertex = UnityObjectToClipPos(pos);
                    o.uv = v.uv;
                    return o;
                }

                // Fragment shader
                half4 frag(v2f i) : SV_Target
                {
                    half4 col = tex2D(_MainTex, i.uv);
                    return col;
                }

                ENDCG
            }
        }
            FallBack "Diffuse"
}
