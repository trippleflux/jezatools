<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <body>
          <table border="1">
            <tr bgcolor="#9acd32">
              <th align="left">Player</th>
              <th align="left">Aliance</th>
              <th align="left">Vilage</th>
              <th align="left">Population</th>
              <th align="left">CoordX</th>
              <th align="left">CoordY</th>
            </tr>
            <xsl:for-each select="//attackAction">
              <xsl:sort select="id" order="ascending" data-type="number"/>
              <tr>
                <td>
                  <a href="{@playerlink}"><xsl:value-of select="@playername"/></a>
                </td>
                <td>
                  <a href="{@aliancelink}"><xsl:value-of select="@aliance"/></a>
                </td>
                <td>
                  <a href="{@villagelink}"><xsl:value-of select="@villagename"/></a>
                </td>
                <td>
                  <xsl:value-of select="@population"/>
                </td>
                <td>
                  <xsl:value-of select="@coordinateX"/>
                </td>
                <td>
                  <xsl:value-of select="@coordinateY"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
  
</xsl:stylesheet>
