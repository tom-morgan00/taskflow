import axios from "axios";
import { useEffect, useState } from "react";
import AppLayout from "../layout/AppLayout";
import { Outlet } from "react-router";

export default function AppPage() {
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
    <AppLayout>
      <Outlet />
    </AppLayout>
  );
}
