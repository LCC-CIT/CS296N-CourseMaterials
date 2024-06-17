// Import the 'axios' module for making HTTP requests
const axios = require('axios');
// Import the 'fs' module with promises for reading files
const fs = require('fs').promises;
const removeMarkdown = require('remove-markdown');


// URL for the ollama api
const url = "http://localhost:11434/api/generate";

// Define the headers
const headers = {
    "Content-Type": "application/json"
};

// Define the data
const data = {
    "model": "phi3",
    "prompt": "write a one paragraph prose summary of the main topics covered in the following text: ",
    "format": "json",
    "stream": false
}
/*    "options": {
    "temperature": 0.7
    }
};
*/

async function generatePrompt(filePath)
{
    try
    {
        // Read the file content
        const fileContent = await fs.readFile(filePath, 'utf8');

         // Convert markdown to plain text using remove-markdown
         const plainText = removeMarkdown(fileContent);

        // Append the file content to the prompt
        data.prompt += plainText;
    }
    catch (error)
    {
        console.error("Error:", error);
    }


    // Make the POST request
    axios.post(url, data, { headers: headers })
        .then(response =>
        {
            // Parse JSON and log just the "response" property
            let llmResponse = "";
            //  if (response.data.response.answer)
            {
                llmResponse = JSON.parse(response.data.response);
            }
            console.log(llmResponse);
        })
        .catch(error =>
        {
            console.error(`Error: ${error}`);
        })
}

generatePrompt("../LectureNotes/CS296N-LN-WK01D2-Validation.md");