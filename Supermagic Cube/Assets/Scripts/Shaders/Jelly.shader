Shader "Unlit/Jelly"
{
    Properties
    {
        _MainTex ("Albedo Texture", 2D) = "black" {}
        _TintColor("TintColor", Color) = (1,1,1,1)
        _Distance("Distance",Float) = 1
        _Amplitude("Amplitude", Float) = 1
        _Speed("_Speed", Float) = 1
        _Amount("Amount", Range (0.0,1.0)) = 1
        [Toggle] _ZAxis("ZAxis" , Range(0.0, 1.0)) = 0
        [Toggle] _YAxis("YAxis" , Range(0.0, 1.0)) = 0
        [Toggle] _XAxis("XAxis" , Range(0.0, 1.0)) = 0

    }
    SubShader
    {
        Tags {"RenderType"="Opaque" "Queue"="Transparent"}  //transparent perchè dava problemi con l'occlusion
        LOD 100 // level of detail
        
        
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // no ereditarietà quindi includiamo i file con includ 
            #include "UnityCG.cginc"     

            struct appdata  // usata per passare informazione sui vertici
            {
                float4 vertex : POSITION;   
                float2 uv : TEXCOORD0;
            };

            struct v2f  //vert to frag, viene creata nella vertex e usata nella frag
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Distance;
            float _Amplitude;
            float _Speed;
            float _Amount;
            float _ZAxis;
            float _YAxis;
            float _XAxis;


            v2f vert (appdata v)
            {
                v2f o; 
                
                if(_ZAxis == 1) 
                {
                    v.vertex.z += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
                }
                if(_XAxis == 1)
                {
                    v.vertex.x += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;  //time.y è il tempo in secondi
                }
                if(_YAxis == 1)
                {
                    v.vertex.y += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;  
                    
                }
                
                o.vertex = UnityObjectToClipPos(v.vertex);  // converto i vertici to screen space
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)+ _TintColor;
                col.a = 1;
                
                return col;
            }
            ENDCG
        }
    }
}
