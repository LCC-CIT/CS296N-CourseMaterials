<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet verison="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/week">
  <html>
    <head>
      <style>
        body {
          font-family: 'Arial', 'Verdana', 'sans-serif';
          font-size: medium;
        }
        h3, h4 {
          margin-top: 0; margin-bottom:0;
        }
      </style>
    </head>
    <body>
      <h2>Week <xsl:value-of select="number"/></h2>
      <p><h3>Reading</h3></p>
      <h4>Essential Reading</h4>
      <xsl:value-of select="reading"/>
      <p><xsl:apply-templates select="supplemental"/></p>
      <p><xsl:apply-templates select="examples"/></p>
      <p><xsl:apply-templates select="exercises"/></p>
      <p><xsl:apply-templates select="lab"/></p>
    </body>
  </html>
</xsl:template>

<xsl:template match="supplemental">
  <h4>Supplemental Reading</h4>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="examples">
  <h3>Examples</h3>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="exercises">
  <h3>Exercises</h3>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="lab">
  <h3>Lab Assignment <xsl:value-of select="number"/></h3>
    <xsl:for-each select="link">
      <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
    </xsl:for-each>
</xsl:template>

</xsl:stylesheet>
