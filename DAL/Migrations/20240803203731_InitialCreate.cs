using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    adresse1 = table.Column<string>(type: "longtext", nullable: false),
                    adresse2 = table.Column<string>(type: "longtext", nullable: true),
                    adresse3 = table.Column<string>(type: "longtext", nullable: true),
                    complement = table.Column<string>(type: "longtext", nullable: true),
                    code_postal = table.Column<int>(type: "int", nullable: false),
                    ville = table.Column<string>(type: "longtext", nullable: false),
                    etage = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    porte = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    batiment = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    prix_ht = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tx_tva = table.Column<float>(type: "float", nullable: false),
                    prix_ttc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "longtext", nullable: false),
                    prenom = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "societe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "longtext", nullable: false),
                    siret = table.Column<string>(type: "longtext", nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_societe", x => x.id);
                    table.ForeignKey(
                        name: "FK_societe_adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "batiment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batiment", x => x.id);
                    table.ForeignKey(
                        name: "FK_batiment_adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_batiment_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "longtext", nullable: false),
                    prenom = table.Column<string>(type: "longtext", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.id);
                    table.ForeignKey(
                        name: "FK_service_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client_adresse",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false),
                    adresse_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_adresse", x => new { x.client_id, x.adresse_id });
                    table.ForeignKey(
                        name: "FK_client_adresse_adresse_adresse_id",
                        column: x => x.adresse_id,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_client_adresse_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "devis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: false),
                    mt_ht = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mt_tva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mt_ttc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    date_redaction = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devis", x => x.id);
                    table.ForeignKey(
                        name: "FK_devis_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_devis_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "historique_client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SocieteId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historique_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_historique_client_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historique_client_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "longtext", nullable: false),
                    prenom = table.Column<string>(type: "longtext", nullable: false),
                    BatimentId = table.Column<int>(type: "int", nullable: false),
                    SocieteId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_batiment_BatimentId",
                        column: x => x.BatimentId,
                        principalTable: "batiment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DevisId = table.Column<int>(type: "int", nullable: true),
                    AdresseFacturationId = table.Column<int>(type: "int", nullable: false),
                    AdresseLivraisonId = table.Column<int>(type: "int", nullable: true),
                    SocieteId = table.Column<int>(type: "int", nullable: false),
                    mt_ht = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mt_tva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    mt_ttc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    net_a_payer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reglee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    date_facturation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_creation = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facture", x => x.id);
                    table.ForeignKey(
                        name: "FK_facture_adresse_AdresseFacturationId",
                        column: x => x.AdresseFacturationId,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facture_adresse_AdresseLivraisonId",
                        column: x => x.AdresseLivraisonId,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_facture_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facture_devis_DevisId",
                        column: x => x.DevisId,
                        principalTable: "devis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_facture_societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "societe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ligne_devis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nligne = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "varchar(1)", nullable: false),
                    quantite = table.Column<float>(type: "float", nullable: false),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    devis_id = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligne_devis", x => x.id);
                    table.ForeignKey(
                        name: "FK_ligne_devis_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ligne_facture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nligne = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "varchar(1)", nullable: false),
                    quantite = table.Column<float>(type: "float", nullable: false),
                    libelle = table.Column<string>(type: "longtext", nullable: false),
                    facture_id = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligne_facture", x => x.id);
                    table.ForeignKey(
                        name: "FK_ligne_facture_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_batiment_AdresseId",
                table: "batiment",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_batiment_SocieteId",
                table: "batiment",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_client_SocieteId",
                table: "client",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_client_adresse_adresse_id",
                table: "client_adresse",
                column: "adresse_id");

            migrationBuilder.CreateIndex(
                name: "IX_devis_ClientId",
                table: "devis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_devis_SocieteId",
                table: "devis",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_BatimentId",
                table: "employee",
                column: "BatimentId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_ServiceId",
                table: "employee",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_SocieteId",
                table: "employee",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_facture_AdresseFacturationId",
                table: "facture",
                column: "AdresseFacturationId");

            migrationBuilder.CreateIndex(
                name: "IX_facture_AdresseLivraisonId",
                table: "facture",
                column: "AdresseLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_facture_ClientId",
                table: "facture",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_facture_DevisId",
                table: "facture",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_facture_SocieteId",
                table: "facture",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_historique_client_ClientId",
                table: "historique_client",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_historique_client_SocieteId",
                table: "historique_client",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_devis_ArticleId",
                table: "ligne_devis",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_devis_devis_id",
                table: "ligne_devis",
                column: "devis_id");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_facture_ArticleId",
                table: "ligne_facture",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_facture_facture_id",
                table: "ligne_facture",
                column: "facture_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_SocieteId",
                table: "service",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_societe_AdresseId",
                table: "societe",
                column: "AdresseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_adresse");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "historique_client");

            migrationBuilder.DropTable(
                name: "ligne_devis");

            migrationBuilder.DropTable(
                name: "ligne_facture");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "batiment");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "facture");

            migrationBuilder.DropTable(
                name: "devis");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "societe");

            migrationBuilder.DropTable(
                name: "adresse");
        }
    }
}
