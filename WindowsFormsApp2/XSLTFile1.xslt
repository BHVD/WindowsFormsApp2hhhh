<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet  version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns="http://www.w3.org/TR/REC-html40">
	<xsl:output method ="html" />
	<xsl:template match="/" >
		<html>
			<table border="2">

				<tr>
					<td>Ma</td>
					<td>Ten</td>
					<td>Mo ta </td>
					<td>Gia </td>
					<td>So luong</td>
				</tr>
		




				<xsl:for-each select="/QLGV/sanpham">
					<tr>
						<td>
							<xsl:value-of select ="Ma"/>
						</td>
						<td>
							<xsl:value-of select ="Ten"/>
						</td>
						<td>
							<xsl:value-of select ="gia"/>
						</td>
						<td>
							<xsl:value-of select ="Mota"/>
						</td>
						<td>
							<xsl:value-of select ="Soluong"/>
						</td>
					</tr>

				</xsl:for-each>
			</table>

				</html>
	</xsl:template>
</xsl:stylesheet>
