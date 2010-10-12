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
            <th align="left">VillageName</th>
            <th align="left">PlayerName</th>
            <th align="left">AllianceName</th>
            <th align="left">Coordinates</th>
            <th align="left">Population</th>
            <th align="left">Status</th>
          </tr>
          <xsl:for-each select="//MapCoordinates">
            <tr>
              <td>
                <a href="{PlayerNameLink}">
                  <xsl:value-of select="PlayerName"/>
                </a>
              </td>
              <td>
                <a href="{VillageLink}">
                  <xsl:value-of select="VillageName"/>
                </a>
              </td>
              <td>
                <a href="{AllianceLink}">
                  <xsl:value-of select="AllianceName"/>
                </a>
              </td>
              <td>
                <xsl:value-of select="Coordinates"/>
              </td>
              <td>
                <xsl:value-of select="Population"/>
              </td>
              <td>
                <a href="{PlayerStatusLink}">
                  <xsl:value-of select="PlayerStatus"/>
                </a>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
