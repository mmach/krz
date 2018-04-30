<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
     <xsl:variable name="dt" select="UserDto/Guid"/>
      <xsl:variable name="data" select="UserDto/BirthDate"/>
  
    <html>
      <body>
        <p>
          Geachte  <xsl:value-of select="UserDto/Name"/>
        </p>

        <p>
          Bedankt voor uw aanvraag voor een QR code om gebruik te maken van de WasApp+.
          <br/>Hieronder staan de gegevens zoals wij die van u hebben ontvangen.
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
           <p>
          Wilt u toch iets wijzigen? Geen probleem.
          <br/>U kunt dit bespreken met een van onze medewerkers van de klantenservice, die de
          <br/>eerstvolgende werkdag contact met u opneemt.

        </p>
        <p>
          Met vriendelijke groet,<br/>
          LIPS+ Klantenservice
        </p>

        <img src="http://52.169.31.40:8559/Content/lips.png" alt="Lips+ logo"/>
        <p style="font-size:12px">
          Wij zijn op werkdagen bereikbaar tussen 8.00-17.00 uur op telefoonnummer 0492-36 13 09 of per e-mail: gemertklantenservice@lipsplus.nl.
        </p>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
