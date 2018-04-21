Shader "Mask"
{
    SubShader
    {
        Tags{ "RenderType" = "Opaque" "Queue" = "Geometry-1" }
 
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }
 
        ColorMask 0
        ZWrite off
 
        Pass {}
    }
}