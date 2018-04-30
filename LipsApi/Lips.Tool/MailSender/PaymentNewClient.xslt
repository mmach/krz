<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <xsl:variable name="dt" select="RegisterUserDto/DateOfBirth"/>
    <html>
      <body>
        <p>
          Geachte  <xsl:value-of select="RegisterUserDto/Name"/>
      </p>
       
        <p>
          Bedankt voor het afgeven van een machtiging tot automatische afschrijving van de wasserij factuur.
         <br/> Wij zullen de volgende gegevens in ons systeem verwerken en in het vervolg de facturen automatisch gaan incasseren.
        </p>
        <table border="0" width="500px">
          <colgroup>
            <col style="width: 20%"/>
            <col style="width: 80%"/>
          </colgroup>
          <tr>
            <td>Naam Client:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/Name"/>
            </td>
          </tr>
          <tr>
            <td>Kamer:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/InstitutionHouseNumber"/>
            </td>
          </tr>
          <tr>
            <td>Instelling:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/InstitutionId"/>
            </td>
          </tr>
          <tr>
            <td>Stad:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/City"/>
            </td>
          </tr>
          <tr>
            <td>Geboortedatum:</td>
            <td>
              <xsl:value-of select="concat(
                      substring($dt, 9, 2),
                      '/',
                      substring($dt, 6, 2),
                      '/',
                      substring($dt, 1, 4)
                      )"/>
            </td>
          </tr>

          <tr>
            <td>Emailadres:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/Email"/>
            </td>
          </tr>
          <tr>
            
            <td>IBAN nummer:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/IBAN"/>
            </td>
          </tr>
          <tr>
            <td>BIC nummer:</td>
            <td>
              <xsl:value-of select="RegisterUserDto/BankId"/>
            </td>
          </tr>
        
    </table>
      
        <p>
           Mocht u in de toekomst toch niet akkoord zijn met de afschrijving van een specifieke factuur,
          <br/> dan kunt u deze zonder opgave van reden terug laten boeken.

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
