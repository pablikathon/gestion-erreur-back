<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="html" indent="yes" />

    <xsl:template match="/" name="TopLevelReport">
        <html>
            <head>
                <title>Test unitaire</title>
                <link type="text/css"
                    href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css"
                    rel="stylesheet"
                    integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU"
                    crossorigin="anonymous" />
                <script
                    src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js"
                    integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ"
                    crossorigin="anonymous"></script>
            </head>
            <body class="d-flex flex-column min-vh-100 bg-light">
                <!-- Header-->
                <header class="bg-secondary py-5">
                    <div class="container px-5">
                        <div class="row gx-5 justify-content-center">
                            <div class="col-lg-6">
                                <div class="text-center my-5">
                                    <img class="d-block mx-auto mb-4"
                                        src="./xunit-coverlet-icon.png"
                                        alt="" height="100" />
                                    <h1 class="display-5 fw-bolder text-white mb-2">Test unitaire</h1>
                                </div>
                            </div>
                        </div>
                    </div>
                </header>

                <content class="bg-light py-5">
                    <div class="container">
                        <div class="accordion accordion-flush">
                            <xsl:for-each select="/testsuites/testsuite/testcase">
                                <div class="accordion-item">
                                    <h2 class="accordion-header">
                                        <button class="accordion-button collapsed" type="button"
                                            data-bs-toggle="collapse"
                                            aria-expanded="false" aria-controls="flush-collapseOne">
                                            <!-- Attribution de l'ID -->
                                            <xsl:attribute name="data-bs-target">
                                                #<xsl:value-of select="generate-id()" />
                                            </xsl:attribute>

                                            <!-- Vérification de l'existence d'un élément <error> -->
                                            <xsl:choose>
                                                <xsl:when test="error">
                                                    <xsl:attribute name="class">badge bg-danger</xsl:attribute>
                                                    <span>Error</span>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <xsl:attribute name="class">badge bg-success</xsl:attribute>
                                                    <span>Success</span>
                                                </xsl:otherwise>
                                            </xsl:choose>

                                            <!-- Affichage du nom de la fonction -->
                                            : <xsl:value-of select="@name" />
                                        </button>
                                    </h2>

                                    <!-- Contenu de l'accordéon -->
                                    <div class="accordion-collapse collapse">
                                        <xsl:attribute name="id">
                                            <xsl:value-of select="generate-id()" />
                                        </xsl:attribute>
                                        <div class="accordion-body">
                                            <table class="table table-hover" style="width:100%">
                                                <thead class="table-dark">
                                                    <tr>
                                                        <th>File</th>
                                                        <th>Executing time</th>
                                                        <th>Message</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td><xsl:value-of select="@classname" /></td>
                                                        <td><xsl:value-of select="@time" /></td>
                                                        <td>
                                                            <xsl:choose>
                                                                <xsl:when test="error">
                                                                    <xsl:value-of select="error" />
                                                                </xsl:when>
                                                                <xsl:otherwise>
                                                                    No error message.
                                                                </xsl:otherwise>
                                                            </xsl:choose>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </xsl:for-each>
                        </div>
                    </div>
                </content>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
