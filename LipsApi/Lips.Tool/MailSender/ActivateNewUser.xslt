<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
     <xsl:variable name="dt" select="UserDto/Guid"/>
      <xsl:variable name="data" select="UserDto/BirthDate"/>
  
    <html>
      <body style="width:700px;">
        <p>
          Geachte  <xsl:value-of select="UserDto/Name"/>
        </p>

        <p>
          Bedankt voor uw aanvraag. Vanaf heden is uw account voor WasApp+ actief.
          <br/>Met behulp van onderstaande QR-code kunt u eenvoudig inloggen en van onze toepassing gebruik maken
        </p>
       
              <img src="http://52.169.31.40:8559/Content/QR/{$dt}.png" style="width:200px" />
          
       
           <p>
             Als u vragen heeft over het gebruik van de WasApp+, zal een van onze service medewerkers u graag verder helpen.

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
