import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  const [tasks, setTasks] = useState<Task[]>([]);
  useEffect(() => {
    async function getTasks() {
      const { data } = await axios.get("https://localhost:5001/api/tasks");
      console.log(data);
      setTasks(data);
    }
    getTasks();
  }, []);

  if (!tasks) return <p>No tasks.</p>;
  return (
    <>
      {tasks.map((task) => (
        <p key={task.id}>{task.name}</p>
      ))}
    </>
  );
}

export default App;
