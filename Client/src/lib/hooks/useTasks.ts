import agent from "@/lib/api/agent";
import { useQuery } from "@tanstack/react-query";

export default function useTasks(id?: string) {
  const getTasks = useQuery({
    queryKey: ["tasks"],
    queryFn: async () => {
      const result = await agent.get<Task[]>("/tasks");
      return result.data;
    },
  });

  const getTaskById = useQuery({
    queryKey: ["tasks", id],
    queryFn: async () => {
      const result = await agent.get<Task>(`/tasks/${id}`);
      return result.data;
    },
    enabled: !!id,
  });

  return {
    tasks: getTasks.data,
    isLoadingTasks: getTasks.isLoading,
    task: getTaskById.data,
    isLoadingTask: getTaskById.isLoading,
  };
}
