<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <xsl:variable name="dt" select="UserDto/Guid"/>
    <xsl:variable name="data" select="UserDto/BirthDate"/>

    <html>
      <body>

        <p>
          Volgende gegevens svp verwerken en tezamen met de QR code mailen naar de aanvrager:
         
        </p>
        <table border="0" width="500px">
          <colgroup>
            <col style="width: 20%"/>
            <col style="width: 80%"/>
          </colgroup>
          <tr>
            <td>Naam Client:</td>
            <td>
              <xsl:value-of select="UserDto/Name"/>
            </td>
          </tr>
          <tr>
            <td>Adres:</td>
            <td>
              <xsl:value-of select="UserDto/Address"/>
            </td>
          </tr>
          <tr>
            <td>Institutions:</td>
            <td>
              <xsl:value-of select="UserDto/Institution/Address"/>
            </td>
          </tr>
          <tr>
            <td>Clientnummer:</td>
            <td>
              <xsl:value-of select="UserDto/ExternalClientId"/>
            </td>
          </tr>
          <tr>
            <td>Geboortedatum:</td>
            <td>
              <xsl:value-of select="concat(
                      substring($data, 9, 2),
                      '/',
                      substring($data, 6, 2),
                      '/',
                      substring($data, 1, 4)
                      )"/>
            </td>
          </tr>
          <tr>
            <td>Emailadres:</td>
            <td>
              <xsl:value-of select="UserDto/Email"/>
            </td>
          </tr>
          <tr>
            <td>QR Code:</td>
            <td>
              <img src="http://52.169.31.40:8559/Content/QR/{$dt}.png" style="width:200px" />
            </td>
          </tr>
        </table>
       
      
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
