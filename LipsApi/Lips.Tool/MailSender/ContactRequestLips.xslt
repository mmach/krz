<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <html>
      <body>
      

        <p>
          Svp contact opnemen met:
        </p>
        <table border="0" width="500px">
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 75"/>
          </colgroup>
         
          <tr>
            <td>Naam aanvrager:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/Name"/>

            </td>
          </tr>
          <tr>
            <td>Telefoonnummer:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/PhoneNumber"/>

            </td>
          </tr>
          <tr>
            <td>Emailadres:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/Email"/>
            </td>
          </tr>
        </table>

        <p>Inzake:
        </p>
        <table border="0" width="500px">
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 75"/>
          </colgroup>
          <tr>
            <td>ClientId:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/ClientId"/>
            </td>
          </tr>
          <tr>
            <td>Naam Client:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/NameAuth"/>
            </td>
          </tr>
          <tr>
            <td>Adres:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/Address"/>
            </td>
          </tr>
          <tr>
            <td>Institutions:</td>
            <td>
              <xsl:value-of select="ContactRequestObject/Institution"/>
            </td>
          </tr>
        </table>
       
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
