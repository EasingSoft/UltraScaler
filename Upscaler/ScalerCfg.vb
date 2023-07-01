Imports System

Namespace xBRZ
	' Token: 0x02000017 RID: 23
	Public Class ScalerCfg
		' Token: 0x17000037 RID: 55
		' (get) Token: 0x06000096 RID: 150 RVA: 0x000072A0 File Offset: 0x000054A0
		' (set) Token: 0x06000097 RID: 151 RVA: 0x000072A8 File Offset: 0x000054A8
		Public Property LuminanceWeight As Double = 1.0

		' Token: 0x17000038 RID: 56
		' (get) Token: 0x06000098 RID: 152 RVA: 0x000072B1 File Offset: 0x000054B1
		' (set) Token: 0x06000099 RID: 153 RVA: 0x000072B9 File Offset: 0x000054B9
		Public Property EqualColorTolerance As Double = 30.0

		' Token: 0x17000039 RID: 57
		' (get) Token: 0x0600009A RID: 154 RVA: 0x000072C2 File Offset: 0x000054C2
		' (set) Token: 0x0600009B RID: 155 RVA: 0x000072CA File Offset: 0x000054CA
		Public Property DominantDirectionThreshold As Double = 3.6

		' Token: 0x1700003A RID: 58
		' (get) Token: 0x0600009C RID: 156 RVA: 0x000072D3 File Offset: 0x000054D3
		' (set) Token: 0x0600009D RID: 157 RVA: 0x000072DB File Offset: 0x000054DB
		Public Property SteepDirectionThreshold As Double = 2.2
	End Class
End Namespace
