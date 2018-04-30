<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="xml" encoding="utf-8" indent="no"/>

  <xsl:template match="/">
    <xsl:variable name="md" select="RegisterUserDto/ModifiedDate"/>
    <xsl:variable name="dt" select="RegisterUserDto/DateOfBirth"/>

    <html>
      <head>
        <style>
          table {
          font-family: arial, sans-serif;
          border-collapse: collapse;
          width: 700px;
          }

          td, th {
          border: 1px solid #333333;
          text-align: left;
          padding: 2px  1px 2px 3px;

          }


        </style>
      </head>
      <body style="max-width:850px;">
        <h2>
          Doorlopende machtiging SEPA - LipsPlus B.V. PARTICULIEREN
        </h2>
        <h4 class="font-weight:700">Doorlopende machtiging SEPA - LipsPlus B.V. PARTICULIEREN</h4>
        <p>
   Ondergetekende verleent hierbij tot wederopzegging een doorlopende machtiging aan LipsPLus B.V. om van zijn/haar bankrekening periodiek bedragen af te schrijven voor facturen textielreiniging/ stoomgoed. Het af te schrijven bedrag is afhankelijk van de afgenomen diensten. Als u het niet eens bent met een afschrijving, dan kunt u binnen 56 kalenderdagen uw bank opdracht geven de betaling terug te boeken.</p>

        <br/>
        <table border="0" width="500px">
        <colgroup>
          <col style="width: 30%"/>
          <col style="width: 70%"/>
        </colgroup>
        <tr>
          <td style=" border: 0px none ;">Incassanten ID:</td>
          <td style=" border: 0px none ;">
            <xsl:value-of select="RegisterUserDto/IBAN"/>
          </td>
        </tr>
          <tr>
            <td style=" border: 0px none ;">Machtigingskenmerk:</td>
            <td style=" border: 0px none ;">
             Facturen textielreiniging/stoomgoed"
            </td>
          </tr>
      </table>
        <br/>
        <br/>
        <table bgcolor="#ffce06">
          <tr>
            <td>
              <span style="font-weight:700">Locatie </span>
              <span>(test)</span>
            </td>
          </tr>
        </table>
        <table >
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 60%"/>
            <col style="width: 15%"/>
          </colgroup>
          <tr>
            <td>Locatie</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/InstitutionId"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Afdeling en kamernummer</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/InstitutionHouseNumber"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
        </table>




        <table bgcolor="#ffce06" colsize="1px;">

          <tr>
            <td>
              <span style="font-weight:700">Gegevens cliënt</span>
            </td>
          </tr>
        </table>
        <table >
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 60%"/>
            <col style="width: 15%"/>
          </colgroup>
          <tr>
            <td >Naam en voorletters</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/Name"/> ]</td>
            <td style=" border-left: 0px none ;">
              <xsl:if test="RegisterUserDto/Gender = 0">Dhr</xsl:if><xsl:if test="RegisterUserDto/Gender = 1">Mw</xsl:if>
            </td>
          </tr>
          <tr>
            <td >Adres</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/Street"/> , <xsl:value-of select="RegisterUserDto/HouseNumber"/>]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Postcode en plaats</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/PostCode"/> , <xsl:value-of select="RegisterUserDto/City"/>]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Telefoonnummer</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/Phone"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >E-mail</td>
            <td style=" border-right: 0px none ;">[ <xsl:value-of select="RegisterUserDto/Email"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Geboortedatum</td>
            <td style=" border-right: 0px none ;">
              [ <xsl:value-of select="concat(
                      substring($dt, 9, 2),
                      '/',
                      substring($dt, 6, 2),
                      '/',
                      substring($dt, 1, 4)
                      )"/> ]
            </td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
        </table>


        <table bgcolor="#ffce06" colsize="1px;">

          <tr>
            <td>
              <span style="font-weight:700">Gegevens financieel contactadres</span> (indien van toepassing)
            </td>
          </tr>
        </table>
        <table >
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 60%"/>
            <col style="width: 15%"/>
          </colgroup>
          <tr>
            <td >Naam en voorletters</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Adres</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Postcode en plaats</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >Telefoonnummer</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >E-mail</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
        </table>


        <table bgcolor="#ffce06" colsize="1px;">

          <tr>
            <td>
              <span style="font-weight:700">Gegevens rekeninghouder</span>
            </td>
          </tr>
        </table>
        <table >
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 60%"/>
            <col style="width: 15%"/>
          </colgroup>
          <tr>
            <td >Naam en voorletters</td>
            <td style=" border-right: 0px none ;">
              [ <xsl:value-of select="RegisterUserDto/Name"/> ]</td>
            <td style=" border-left: 0px none ;">  <xsl:if test="RegisterUserDto/Gender = 0">Dhr</xsl:if><xsl:if test="RegisterUserDto/Gender = 1">Mw</xsl:if> </td>
          </tr>
          <tr>
            <td >Woonplaats</td>
            <td style=" border-right: 0px none ;">[  ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >IBAN nummer</td>
            <td style=" border-right: 0px none ;">
              [  <xsl:value-of select="RegisterUserDto/IBAN"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr>
            <td >BIC nummer</td>
            <td style=" border-right: 0px none ;">
              [  <xsl:value-of select="RegisterUserDto/BankId"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
        </table>


        <table bgcolor="#ffce06" colsize="1px;">

          <tr>
            <td>
              <span style="font-weight:700">Datum en handtekening</span>
            </td>
          </tr>
        </table>
        <table >
          <colgroup>
            <col style="width: 25%"/>
            <col style="width: 60%"/>
            <col style="width: 15%"/>
          </colgroup>
          <tr>
            <td >Datum</td>
            <td style=" border-right: 0px none ;">
              [  <xsl:value-of select="concat(
                      substring($md, 9, 2),
                      '/',
                      substring($md, 6, 2),
                      '/',
                      substring($md, 1, 4)
                      )"/> ]</td>
            <td style=" border-left: 0px none ;"></td>
          </tr>
          <tr height="100px">
            <td >Handtekening</td>
            <td style=" border-right: 0px none ;"></td>
            <td style=" border-left: 0px none ;"></td>
          </tr>


        </table>
      </body>
    </html>
   
      

  </xsl:template>

</xsl:stylesheet>
