import { ColumnDef } from "@tanstack/react-table";
import TaskOptions from "./TaskOptions";
import { formatDate } from "@/lib/utils";
import { Badge } from "@/components/ui/badge";

export const columns: ColumnDef<Task>[] = [
  {
    accessorKey: "name",
    header: "Name",
  },
  {
    accessorKey: "status",
    header: "Status",
    cell: ({ row }) => {
      const status = row.original.status;
      return (
        <Badge
          variant={
            status === "Done"
              ? "secondary"
              : status === "InProgress"
              ? "default"
              : "outline"
          }
        >
          {row.original.status}
        </Badge>
      );
    },
  },
  {
    accessorKey: "dueDate",
    header: "Due date",
    cell: ({ row }) => row.original.dueDate && formatDate(row.original.dueDate),
  },
  {
    accessorKey: "createdAt",
    header: "Created at",
    cell: ({ row }) => formatDate(row.original.createdAt),
  },
  {
    id: "actions",
    cell: ({ row }) => {
      const task = row.original;

      return <TaskOptions task={task} />;
    },
  },
];
