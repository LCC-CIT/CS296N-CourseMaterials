<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
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

        ul {
          list-style-type: none;
          padding: 0;
          margin: 0;
        }

          li.doc {
            background-image: url(images/document-24.png);
            background-repeat: no-repeat;
            background-position: 0.4em;
            padding-left: 2em;
            padding-bottom: 0.35em;
            padding-top: 0.35em;
          }

          li.link {
            background-image: url(images/icon.svg);
            background-repeat: no-repeat;
            background-position: 0.4em;
            padding-left: 2em;
            padding-bottom: 0.35em;
            padding-top: 0.35em;
          }

          li.github {
            background-image: url(images/octocat-24.png);
            background-repeat: no-repeat;
            background-position: 0.4em;
            padding-left: 2em;
            padding-bottom: 0.35em;
            padding-top: 0.35em;
          }
      </style>
    </head>
    <body>
      <h2>Week <xsl:value-of select="number"/></h2>
      <p><h3>Reading</h3></p>

      <p><xsl:apply-templates select="reading"/></p>
      <p><xsl:apply-templates select="supplemental"/></p>
      <p><xsl:apply-templates select="examples"/></p>
      <p><xsl:apply-templates select="exercises"/></p>
      <p><xsl:apply-templates select="lab"/></p>
    </body>
  </html>
</xsl:template>

<xsl:template match="reading">
  <h4>Essential Reading</h4>
  <ul>
  <xsl:for-each select="title">
    <li> <xsl:value-of select="."/>
    </li>
  </xsl:for-each>
</ul>
</xsl:template>

<xsl:template match="supplemental">
  <h4>Supplemental Reading</h4>
  <ul>
  <xsl:for-each select="link">
    <li class="link"><a href="{url}" title="{title}"
      target="_blank"><xsl:value-of select="text"/></a>
    </li>
  </xsl:for-each>
</ul>
</xsl:template>

<xsl:template match="examples">
  <h3>Examples</h3>
  <ul>
  <xsl:for-each select="link">
    <li class="github"><a href="{url}" title="{title}"
      target="{target}"><xsl:value-of select="text"/></a>
    </li>
  </xsl:for-each>
</ul>
</xsl:template>

<xsl:template match="exercises">
  <h3>Exercises</h3>
  <ul>
  <!-- for html links -->
  <xsl:for-each select="link">
    <li><a href="{url}" title="{title}"
      target="{target}"><xsl:value-of select="text"/></a>
    </li>
    <!-- for text -->
  </xsl:for-each>
    <xsl:for-each select="title">
    <li> <xsl:value-of select="."/>
    </li>
  </xsl:for-each>
</ul>
</xsl:template>

<xsl:template match="lab">
  <h3>Lab Assignment <xsl:value-of select="number"/></h3>
  <ul>
    <xsl:for-each select="link">
      <li class="doc"><a href="{url}" title="{title}">
         <xsl:value-of select="text"/></a>
    </li>
    </xsl:for-each>
  </ul>
</xsl:template>

</xsl:stylesheet>
