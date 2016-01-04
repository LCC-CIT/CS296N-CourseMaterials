<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet verison="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/week">
  <html>
    <body>
      <p><b>Week <xsl:value-of select="number"/></b></p>
      <p><b>Reading</b></p>
      <xsl:value-of select="reading"/>
      <xsl:apply-templates select="supplemental"/>
      <xsl:apply-templates select="examples"/>
      <xsl:apply-templates select="exercises"/>
      <xsl:apply-templates select="lab"/>
    </body>
  </html>
</xsl:template>

<xsl:template match="supplemental">
  <p><b>Supplemental Reading</b></p>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="examples">
  <p><b>Examples</b></p>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="exercises">
  <p><b>Exercises</b></p>
  <xsl:for-each select="link">
    <a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    <br/>
  </xsl:for-each>
</xsl:template>

<xsl:template match="lab">
  <p><b>Lab Assignment <xsl:value-of select="number"/></b></p>
    <xsl:for-each select="link">
      <a href="{url}" title="{title}"
      target="_blank">Instructions</a>
      <br/>
    </xsl:for-each>
</xsl:template>

</xsl:stylesheet>
