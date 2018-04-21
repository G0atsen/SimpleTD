Shader "MaskableWall"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
    }
 
    SubShader
    {
        Tags{ "RenderType" = "Opaque" "Queue" = "Geometry+1" }
 
        Pass
        {
            Stencil
            {
                Ref 0
                Comp equal
                Fail zero
            }
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
           
            fixed4 _Color;
 
            struct appdata
            {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float4 pos : SV_POSITION;
            };
 
            float4 vert(appdata v) : SV_POSITION
            {
                return UnityObjectToClipPos(v.vertex);
            }
 
            half4 frag(float4 i : SV_POSITION) : SV_Target
{
                return _Color;
            }
 
            ENDCG
        }
    }
}