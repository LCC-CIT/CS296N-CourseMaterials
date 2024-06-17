const fs = require('fs');
const path = require('path');
const axios = require('axios'); // Changed from request-promise to axios
const cheerio = require('cheerio');
const http = require('http');
const directory = "..\\LectureNotes";
const baseUrl = "http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/";

// Function to generate the web page
const generateWebPage = async () => {
    // Include Bootstrap CDN in the head section for styling
    let linksHtml = `
  <html>
  <head>
  <title>Course Materials</title>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  </head>
  <body>
  <div class="container">
    <h1 class="mt-5">Course Lecture Notes</h1>\n`;
  
    const weekGroups = new Map();
  
    try {
      const files = fs.readdirSync(directory).filter(file => path.extname(file).toLowerCase() === '.html');
      
      // Populate weekGroups map
      for (const file of files) {
        const weekMatch = file.match(/WK(\d+|0X)/i);
        const weekNumber = weekMatch ? weekMatch[1] : "Unknown Week";
        if (!weekGroups.has(weekNumber)) {
          weekGroups.set(weekNumber, []);
        }
        weekGroups.get(weekNumber).push(file);
      }
  
      // Generate HTML for each group with Bootstrap classes for styling
      for (const [weekNumber, files] of weekGroups) {
        linksHtml += `<div class="mt-4"><h2 class="h4">Week ${weekNumber}</h2>\n`;
        for (const file of files) {
          const url = baseUrl + file;
          try {
            const response = await axios.get(url);
            const $ = cheerio.load(response.data);
            const title = $('h1').text() || file;
            // Use Bootstrap's 'btn' and 'btn-link' classes for link styling
            linksHtml += `<a href='${url}' class="btn btn-link">${title}</a><br>\n`;
          } catch (error) {
            console.error(`Error fetching ${url}:`, error.message);
          }
        }
        linksHtml += `</div>`;
      }
  

    linksHtml += "</body>\n</html>";

    // Write the generated HTML to a file named homeLinks.html
fs.writeFile('homeLinks.html', linksHtml, (err) => {
    if (err) {
      throw err;
    } else {
      console.log("homeLinks.html has been created.");
    }
  });
  }
  catch {
    console.error("Error writing to file:", err.message);
  }
}

generateWebPage();