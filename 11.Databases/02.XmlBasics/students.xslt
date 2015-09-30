<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
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
          .student-container
          {
            width:50%;
            margin:10px;
            background:dodgerblue;
            color:white;
            font-size:20px;
            padding:10px;
            border-radius:10px;
          }
          .exam-title
          {
            margin-left:20px;
          }
          .exam-container
          {
            margin-left:40px;
          }
        </style>
      </head>
      <body>
        <h2>Students</h2>
        <xsl:for-each select="students/student">
          <div class="student-container">
            Name: <xsl:value-of select="name"/>
            <div>
              Faculty Number: <xsl:value-of select="@faculty-number"/>
            </div>
            <div class="exam-title">Taken exams:</div>
            <xsl:for-each select="taken-exams/exam">
              <div class="exam-container">
                <xsl:value-of select="position()"/>. <xsl:value-of select="name"/> - Score: <xsl:value-of select="grade"/> (Tutor: <xsl:value-of select="tutor"/>)
              </div>
            </xsl:for-each>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>


