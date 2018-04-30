<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <html>
      <body>
        <p>
          Geachte  <xsl:value-of select="RegisterUserDto/Name"/>
        </p>

        <p>
          Hartelijk dank voor uw betaling aan LIPS+.
          Deze mail sturen wij als ontvangstbevestiging voor een bedrag van <xsl:value-of select="RegisterUserDto/Amount"/> op onze rekening.
        </p>

        <p>
          Voor verdere vragen staan wij graag tot uw beschikking.
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
