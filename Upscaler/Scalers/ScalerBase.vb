Namespace xBRZ.Scalers
    ' Token: 0x0200001E RID: 30
    Friend MustInherit Class ScalerBase
        ' Token: 0x060000B7 RID: 183 RVA: 0x0000803C File Offset: 0x0000623C
        Protected Shared Sub AlphaBlend(n As Integer, m As Integer, dstPtr As xBRZ.Common.IntPtr, col As Integer)
            Dim dst As Integer = dstPtr.[Get]()
            Dim num As Integer = ScalerBase.BlendComponent(16711680, n, m, dst, col)
            Dim greenComponent As Integer = ScalerBase.BlendComponent(65280, n, m, dst, col)
            Dim blueComponent As Integer = ScalerBase.BlendComponent(255, n, m, dst, col)
            Dim blend As Integer = num Or greenComponent Or blueComponent
            dstPtr.[Set](blend Or -16777216)
        End Sub

        ' Token: 0x060000B8 RID: 184 RVA: 0x00008090 File Offset: 0x00006290
        Private Shared Function BlendComponent(mask As Integer, n As Integer, m As Integer, inPixel As Integer, setPixel As Integer) As Integer
            Dim inChan As Integer = inPixel And mask
            Dim blend As Integer = (setPixel And mask) * n + inChan * (m - n)
            Return mask And blend / m
        End Function
    End Class
End Namespace
