import { useStore } from "@/lib/store";

export default function BearTest() {
  const { isTaskFormOpen, setTaskFormOpen } = useStore();

  return (
    <div>
      <p>{isTaskFormOpen ? "True" : "False"}</p>
      <button onClick={() => setTaskFormOpen(!isTaskFormOpen)}>toggle</button>
    </div>
  );
}
