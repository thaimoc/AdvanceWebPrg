﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">   
        <p>
          <b>
            <xsl:value-of select="Student/MSSV"/>
          </b>
        </p>
    <br/>
        <p>
          <b>
            <xsl:value-of select="Student/HoTen"/>
          </b>          
        </p>
  </xsl:template>
</xsl:stylesheet>
