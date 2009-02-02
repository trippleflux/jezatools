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
              <th align="left">Name</th>
              <th align="left">Aliance</th>
              <th align="left">AttackPoints</th>
              <th align="left">AttackRang</th>
              <th align="left">DefensePoints</th>
              <th align="left">DefenseRang</th>
              <th align="left">Rang</th>
              <th align="left">Population</th>
              <th align="left">VillageCount</th>
            </tr>
            <xsl:for-each select="//player">
              <xsl:sort select="attackpoints" order="descending" data-type="number"/>
              <tr>
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="aliance"/>
                </td>
                <td>
                  <xsl:value-of select="attackpoints"/>
                </td>
                <td>
                  <xsl:value-of select="attackrang"/>
                </td>
                <td>
                  <xsl:value-of select="defensepoints"/>
                </td>
                <td>
                  <xsl:value-of select="defenserang"/>
                </td>
                <td>
                  <xsl:value-of select="rang"/>
                </td>
                <td>
                  <xsl:value-of select="population"/>
                </td>
                <td>
                  <xsl:value-of select="villagecount"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
  
</xsl:stylesheet>
