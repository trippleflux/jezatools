<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th align="left">Distance</th>
            <th align="left">VillageName</th>
            <th align="left">PlayerName</th>
            <th align="left">AllianceName</th>
            <th align="left">Coordinates</th>
            <th align="left">Population</th>
            <th align="left">Action</th>
          </tr>
          <xsl:for-each select="//Valley">
            <tr>
              <td>
                <xsl:value-of select="Distance"/>
              </td>
              <td>
                <a href="http://s5.travian.si/{PlayerUrl}">
                  <xsl:value-of select="Player"/>
                </a>
              </td>
              <td>
                <a href="http://s5.travian.si/{VillageUrl}">
                  <xsl:value-of select="Name"/>
                </a>
              </td>
              <td>
                <a href="http://s5.travian.si/{AllianceUrl}">
                  <xsl:value-of select="Alliance"/>
                </a>
              </td>
              <td>
                <xsl:value-of select="Coordinates"/>
              </td>
              <td>
                <xsl:value-of select="Population"/>
              </td>
              <td>
                <a href="http://s5.travian.si/{SendTroopsUrl}">
                  <xsl:value-of select="SendTroopsText"/>
                </a>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
