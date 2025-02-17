import agent from "@/lib/api/agent";
import { useQuery } from "@tanstack/react-query";

export default function useWorkspaces() {
  const getWorkspaces = useQuery({
    queryKey: ["workspaces"],
    queryFn: async () => {
      const result = await agent.get<Workspace[]>("/workspaces");
      return result.data;
    },
  });

  return {
    workspaces: getWorkspaces.data,
  };
}
