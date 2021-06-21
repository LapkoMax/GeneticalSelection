using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneticalSelection.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kingdoms",
                columns: new[] { "KingdomId", "Description", "LatinName", "Name" },
                values: new object[] { 1L, "Multicellular eukaryotic organisms.", "Animalia", "Animals" });

            migrationBuilder.InsertData(
                table: "Kingdoms",
                columns: new[] { "KingdomId", "Description", "LatinName", "Name" },
                values: new object[] { 2L, "Mainly multicellular organisms, predominantly photosynthetic aukaryotes.", "Plantae", "Plants" });

            migrationBuilder.InsertData(
                table: "Phylums",
                columns: new[] { "PhylumId", "Description", "KingdomId", "LatinName", "Name" },
                values: new object[] { 1L, "Has chorda.", 1L, "Chordata", "Chordate" });

            migrationBuilder.InsertData(
                table: "Phylums",
                columns: new[] { "PhylumId", "Description", "KingdomId", "LatinName", "Name" },
                values: new object[] { 2L, "Land plants with lignified tissues.", 2L, "Vasculum", "Vascular plant" });

            migrationBuilder.InsertData(
                table: "Subphylums",
                columns: new[] { "SubphylumId", "Description", "LatinName", "Name", "PhylumId" },
                values: new object[] { 1L, "Chordates with backbones.", "Vertebrata", "Vertebrates", 1L });

            migrationBuilder.InsertData(
                table: "Subphylums",
                columns: new[] { "SubphylumId", "Description", "LatinName", "Name", "PhylumId" },
                values: new object[] { 2L, "Most diverse group of land plants.", "Angiospermae", "Flowering plant", 2L });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Description", "LatinName", "Name", "SubphylumId" },
                values: new object[] { 1L, "Group of verteble animals.", "Mamma", "Mammal", 1L });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Description", "LatinName", "Name", "SubphylumId" },
                values: new object[] { 2L, "Are one of the two groups into which all the flowering plants or angiosperms were formerly divided.", "Dicotyledon", "Dicotyledonae", 2L });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClassId", "Description", "LatinName", "Name" },
                values: new object[] { 1L, 1L, "Specialized in primary eating flesh.", "Carnivora", "Carnivora" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClassId", "Description", "LatinName", "Name" },
                values: new object[] { 2L, 2L, "Composite flowers made of florets.", "Asterales", "Asterales" });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "FamilyId", "Description", "LatinName", "Name", "OrderId" },
                values: new object[] { 1L, "Dog-like carnivorans.", "Canidae", "Canidae", 1L });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "FamilyId", "Description", "LatinName", "Name", "OrderId" },
                values: new object[] { 2L, "One of the largest families of dicotyledonous plants.", "Asceraceae", "Asceraceae", 2L });

            migrationBuilder.InsertData(
                table: "Genuses",
                columns: new[] { "GenusId", "Description", "FamilyId", "LatinName", "Name" },
                values: new object[] { 1L, "Genus of the Caninae containing multiple extant species.", 1L, "Canis", "Canis" });

            migrationBuilder.InsertData(
                table: "Genuses",
                columns: new[] { "GenusId", "Description", "FamilyId", "LatinName", "Name" },
                values: new object[] { 2L, "Genus comprising about 70 species of annual and perennial flowering plants.", 2L, "Helianthus", "Helianthus" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "Description", "GenusId", "LatinName", "Name" },
                values: new object[] { 1L, "Is a large canine native to Eurasia and North America.", 1L, "Canis lupus", "Gray Wolf" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "SpeciesId", "Description", "GenusId", "LatinName", "Name" },
                values: new object[] { 2L, "The common names sunflower and common sunflower typically refer to the popular annual species Helianthus annuus.", 2L, "Helianthus", "Sunflower" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "SpeciesId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Genuses",
                keyColumn: "GenusId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Genuses",
                keyColumn: "GenusId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "FamilyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "FamilyId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Subphylums",
                keyColumn: "SubphylumId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Subphylums",
                keyColumn: "SubphylumId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Phylums",
                keyColumn: "PhylumId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Phylums",
                keyColumn: "PhylumId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "KingdomId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Kingdoms",
                keyColumn: "KingdomId",
                keyValue: 2L);
        }
    }
}
