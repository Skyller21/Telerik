<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Albums</title>
        <style>
          body
          {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            justify-content: center;
            align-items: center;
          }
          h2
          {
            background:#B00000;
            color:white;
            padding:10px;
            width: 50%;
            border-radius:10px;
          }
          .album-container
          {
            width:50%;
            margin:10px;
            background:dodgerblue;
            color:white;
            font-size:20px;
            padding:10px;
            border-radius:10px;
          }
          .song-title
          {
            margin-left:20px;
          }
          .song-container
          {
            margin-left:40px;
          }
        </style>
      </head>
      <body>
        <h2>Albums</h2>
        <xsl:for-each select="catalogue/album">
          <div class="album-container">
            Album name: <xsl:value-of select="name"/>
            <div>
              Artist: <xsl:value-of select="artist"/>
            </div>
            <div class="song-title">Songs:</div>
            <xsl:for-each select="songs/song">
              <div class="song-container">
                <xsl:value-of select="position()"/>. <xsl:value-of select="@title"/>
              </div>
            </xsl:for-each>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>


