Shader "Custom/WaterWaveShader"
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
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

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

                v2f vert(appdata_t v)
                {
                    v2f o;
                    float WaterWave = sin(_Time.y * _WaveSpeed + v.vertex.x * _WaveFrequency) * _WaveHeight;
                    v.vertex.x -= WaterWave;
                    v.vertex.y += WaterWave;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    half4 col = tex2D(_MainTex, i.uv);
                    return col;
                }
                ENDCG
            }
        }
        FallBack "Mobile/Diffuse"
}
