import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import useWorkspaces from "@/lib/hooks/useWorkspaces";
import { PlusIcon } from "lucide-react";
import { Link, useParams } from "react-router";

export default function WorkspaceList() {
  const { id } = useParams();
  const { workspace } = useWorkspaces(id);
  console.log(workspace);

  if (workspace.isLoading) {
    return <div>Loading...</div>;
  }

  if (!workspace.data) {
    return <div>Workspace not found.</div>;
  }

  return (
    <main className="flex flex-col gap-4">
      <div className="flex justify-between">
        <h1 className="text-2xl">{workspace.data.name}</h1>
        <Button onClick={() => alert("Add new task")}>
          <PlusIcon /> New task
        </Button>
      </div>
      <div className="flex flex-col gap-2">
        {workspace.data.tasks.map((task) => (
          <Link to={`/app/workspaces/${task.id}`}>
            <Card className="w-full p-4 flex gap-4 hover:shadow-md">
              <div className="">
                <p className="bold">{task.name}</p>
                <p className="bold">{task.status}</p>
                <p className="bold">{task.dueDate}</p>
              </div>
            </Card>
          </Link>
        )) || <p>No tasks found</p>}
      </div>
    </main>
  );
}
