import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import useWorkspaces from "@/lib/hooks/useWorkspaces";
import { Image, PlusIcon } from "lucide-react";
import { Link } from "react-router";

export default function WorkspaceList() {
  const { workspaces, isLoadingWorkspaces } = useWorkspaces();

  if (isLoadingWorkspaces) {
    return <div>Loading...</div>;
  }

  if (!workspaces) {
    return <div>Workspaces not found.</div>;
  }
  return (
    <main className="flex flex-col gap-4">
      <div className="flex justify-between">
        <h1 className="text-2xl">Workspaces</h1>
        <Button onClick={() => alert("Add new workspace")}>
          <PlusIcon /> New workspace
        </Button>
      </div>
      <div className="flex flex-col gap-2">
        {workspaces.map((workspace) => (
          <Link to={`/app/workspaces/${workspace.id}`}>
            <Card className="w-full p-4 flex gap-4 hover:shadow-md">
              <Image />
              <div className="">
                <p className="text-lg">{workspace.name}</p>

                <p className="text-gray">{workspace.createdAt.split("T")[0]}</p>
              </div>
            </Card>
          </Link>
        ))}
      </div>
    </main>
  );
}
