import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from "@radix-ui/react-dropdown-menu";
import { MoreHorizontal } from "lucide-react";
import { useNavigate } from "react-router";

type Props = {
  task: Task;
};

export default function TaskOptions({ task }: Props) {
  const navigate = useNavigate();
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" className="h-8 w-8 p-0">
          <span className="sr-only">Open menu</span>
          <MoreHorizontal className="h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent className="p-2 bg-white border rounded-sm flex flex-col gap-1">
        <DropdownMenuItem
          onClick={() =>
            navigate(`/app/workspaces/${task.workspaceId}?task=${task.id}`)
          }
        >
          Edit task
        </DropdownMenuItem>
        <DropdownMenuItem>Delete task</DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
