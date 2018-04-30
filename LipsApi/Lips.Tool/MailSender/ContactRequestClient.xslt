<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <html>
      <body>
        <p>
          Geachte  <xsl:value-of select="ContactRequestObject/Name"/>
        </p>

        <p>
          Bedankt voor uw informatie aanvraag over onze dienstverlening.
          <br/> Hieronder staan de gegevens zoals wij die van u hebben ontvangen.
        </p>
        <table border="0" width="500px">
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 75"/>
          </colgroup>
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

        <p>
          Een van onze medewerkers van de klantenservice zal de eerstvolgende werkdag contact met u opnemen.

        </p>
        <p>
          Met vriendelijke groet,<br/>
          LIPS+ Klantenservice
        </p>

        <img src="http://52.169.31.40:8559/Content/lips.png" alt="Lips+ logo"/>
        <p style="font-size:12px">
          Wij zijn op werkdagen bereikbaar tussen 8.00-17.00 uur op telefoonnummer 0492-36 13 09 of per e-mail:<br/> gemertklantenservice@lipsplus.nl.
        </p>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
