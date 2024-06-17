# Build a Homepage for CS296N Lecture Notes

## Prompt

Write code to crate a web page that contains links to each of the html files in the directory D:\Repos\CS296N-CourseMaterials\LectureNotes. For each link, prepend this address to the file name: http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/CS296N-LN-WK01D1-IntroToCourse.html. For the link text, use the web page h1 heading.

### Python Code from Codestral:

```python
import os
from bs4 import BeautifulSoup
import requests
from urllib.parse import urljoin
from pathlib import Path

base_url = "http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/"
directory = "D:\\Repos\\CS296N-CourseMaterials\\LectureNotes"
html_files = [f for f in os.listdir(directory) if Path(f).suffix == '.html']

with open('links.html', 'w') as file:
    file.write("<html>\n<body>\n")
    for html_file in html_files:
        url = urljoin(base_url, html_file)
        response = requests.get(url)
        soup = BeautifulSoup(response.text, 'html.parser')
        title = soup.h1.string if soup.h1 else html_file
        file.write(f"<a href='{url}'>{title}</a>\n<br>")
    file.write("</body>\n</html>")
```

This script will generate a new HTML page called `links.html` in the same directory as the Python script is located. This page will contain links to each of your html files with their corresponding h1 headings (or the filenames if there are no h1 headings).

### Node Code from Codestral

Here's how you could do it with Node.js, using fs (built-in file system module), path, request-promise and cheerio
libraries:

```javascript
const fs = require('fs');
const path = require('path');
const rp = require('request-promise');
const cheerio = require('cheerio');

const baseUrl = "http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/";
const directory = "D:\\Repos\\CS296N-CourseMaterials\\LectureNotes";

fs.readdir(directory, (err, files) => {
    if (err) console.log(err);
    else {
        let htmlContent = "<html>\n<body>\n";
        const htmlFiles = files.filter(file => path.extname(file).toLowerCase() === '.html');
        Promise.all(htmlFiles.map(async file => {
            const url = baseUrl + file;
            const response = await rp(url);
            const $ = cheerio.load(response);
            const title = $('h1').text() || file;
            htmlContent += `<a href='${url}'>${title}</a>\n<br>`;
        }))
        .then(() => {
            htmlContent += "</body>\n</html>";
            fs.writeFile('links.html', htmlContent, err => {
                if (err) console.log(err);
                else console.log("File written successfully\n");
            });
        })
    }
});
```

This script will generate a new HTML page called `links.html` in the same directory as the Node.js script is located.
This page will contain links to each of your html files with their corresponding h1 headings (or the filenames if there
are no h1 headings).

### Node Code from GitHub  Copilot

To create a web page that contains links to each of the HTML files in the specified directory, and for each link, prepend a specific address to the file name and use the web page's `<h1>` heading as the link text, follow these steps:

1. **Read the directory** to get a list of HTML files.
2. **For each HTML file**, make an HTTP request to fetch its content.
3. **Parse the HTML content** to find the `<h1>` heading.
4. **Generate an HTML file** that contains links to each of the HTML files, using the `<h1>` heading as the link text.

Here's the JavaScript code for Node.js to accomplish this:

```javascript
const fs = require('fs');
const path = require('path');
const rp = require('request-promise');
const cheerio = require('cheerio');
const http = require('http');
const directory = "D:\\Repos\\CS296N-CourseMaterials\\LectureNotes";
const baseUrl = "http://lcc-cit.github.io/CS296N-CourseMaterials/LectureNotes/";

// Function to generate the web page
const generateWebPage = async () => {
  let linksHtml = "<html>\n<head>\n<title>Course Materials</title>\n</head>\n<body>\n<h1>Course Lecture Notes</h1>\n";

  try {
    const files = fs.readdirSync(directory).filter(file => path.extname(file).toLowerCase() === '.html');
    for (const file of files) {
      const url = baseUrl + file;
      try {
        const response = await rp(url);
        const $ = cheerio.load(response);
        const title = $('h1').text() || file;
        linksHtml += `<a href='${url}'>${title}</a><br>\n`;
      } catch (error) {
        console.error(`Error fetching ${url}:`, error.message);
      }
    }

    linksHtml += "</body>\n</html>";

    // Create a server to serve the generated HTML
    http.createServer((req, res) => {
      res.writeHead(200, {'Content-Type': 'text/html'});
      res.write(linksHtml);
      res.end();
    }).listen(8080);

    console.log("Server running at http://localhost:8080/");
  } catch (err) {
    console.error("Error reading directory:", err.message);
  }
};

generateWebPage();
```

This script does the following:

- Reads the specified directory for HTML files.
- For each HTML file, it constructs the URL and fetches the file content using `request-promise`.
- Parses the fetched HTML content with `cheerio` to extract the `<h1>` heading.
- Constructs a string of HTML content that includes links (`<a>` tags) to each HTML file, using the `<h1>` heading as the link text.
- Creates a simple HTTP server using Node.js's `http` module that serves the generated HTML content when accessed.
- Listens on port 8080, so you can view the generated web page by navigating to `http://localhost:8080/` in a web browser.

This script assumes that all HTML files are accessible via the provided base URL and that each file contains an `<h1>` heading to use as the link text.