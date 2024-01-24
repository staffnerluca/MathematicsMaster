import React from 'react';

export function FetchTest() {
    async function tasksFetch() {
        try {
          const response = await fetch("tasks", {
            headers: {
              'Accept': 'application/json', // Ensure that the server knows we expect JSON
            },
          });
    
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
    
          const data = await response.json();
          alert("Got something from Tasks:\n" + JSON.stringify(data));
        } catch (error) {
          console.error("Error fetching data:", error.message);
        }
      }

  return (
    <div>
      <h2>Fetch Test</h2>
      <button onClick={tasksFetch}>Fetch Data from Tasks</button>
    </div>
  );
}
