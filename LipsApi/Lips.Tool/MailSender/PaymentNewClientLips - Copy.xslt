<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <html>
      <body>
        <h2>
          Hi 
        </h2>
        <p>
          Request for new user.
          <br/>Email - <xsl:value-of select="RegisterUserDto/Email"/>,
          <br/>City - <xsl:value-of select="RegisterUserDto/City"/>,
          <br/>Gender - <xsl:if test="RegisterUserDto/Gender = 1">Male</xsl:if><xsl:if test="RegisterUserDto/Gender = 2">Female</xsl:if>,
          <br/>HouseNumber - <xsl:value-of select="RegisterUserDto/HouseNumber"/>,
          <br/>InstitutionHouseNumber - <xsl:value-of select="RegisterUserDto/InstitutionHouseNumber"/>,
          <br/>InstitutionId - <xsl:value-of select="RegisterUserDto/InstitutionId"/>,
          <br/>Name - <xsl:value-of select="RegisterUserDto/Name"/>,
          <br/>Phone - <xsl:value-of select="RegisterUserDto/Phone"/>,
          <br/>PostCode - <xsl:value-of select="RegisterUserDto/PostCode"/>,
          <br/>Street - <xsl:value-of select="RegisterUserDto/Street"/>,
          <br/>Guid - <xsl:value-of select="RegisterUserDto/Guid"/>,
          <br/>BankId -  <xsl:value-of select="RegisterUserDto/BankId"/>
        </p>
        Regards,<br/>
        WasApp
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
