import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import {
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
  Form,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { useStore } from "@/lib/store";
import { Textarea } from "@/components/ui/textarea";
import { useNavigate, useSearchParams } from "react-router";
import { useEffect } from "react";
import useTasks from "@/lib/hooks/useTasks";

const formSchema = z.object({
  name: z.string().min(1, "Name is required"),
  description: z.string().optional(),
  status: z.enum(["ToDo", "InProgress", "Done"]),
  dueDate: z.string().min(1, "Due date is required"),
  workspaceId: z.string().min(1, "Workspace is required"),
});

type Props = {
  workspace: Workspace;
};

export default function TaskForm({ workspace }: Props) {
  const [searchParams] = useSearchParams();
  const navigate = useNavigate();
  const taskId = searchParams.get("task") || undefined;
  const { task, isLoadingTask } = useTasks(taskId);
  const { isTaskFormOpen, setTaskFormOpen } = useStore();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: task?.name || "",
      description: task?.description || "",
      status: task?.status || "ToDo",
      dueDate: task?.dueDate || new Date().toISOString().split("T")[0],
      workspaceId: workspace.id || "",
    },
  });

  useEffect(() => {
    if (task) {
      setTaskFormOpen(true);
      form.reset({
        name: task.name,
        description: task.description,
        status: task.status,
        dueDate: task.dueDate,
        workspaceId: task.workspaceId,
      });
    } else {
      form.reset({
        name: "",
        description: "",
        status: "ToDo",
        dueDate: new Date().toISOString().split("T")[0],
        workspaceId: workspace.id,
      });
    }
  }, [task, form, workspace, setTaskFormOpen]);

  const closeTaskForm = () => {
    setTaskFormOpen(false);
    form.reset();
    if (task) {
      navigate(`/app/workspaces/${workspace.id}`, { replace: true });
    }
  };

  function onSubmit(values: z.infer<typeof formSchema>) {
    console.log(values);
    closeTaskForm();
  }

  return (
    <Dialog open={isTaskFormOpen} onOpenChange={closeTaskForm}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>{task ? "Edit task" : "Create task"}</DialogTitle>
          <DialogDescription>
            {task
              ? "Enter details and update task"
              : "Enter details to create a new task"}
          </DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
            <FormField
              control={form.control}
              name="name"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input placeholder="Enter name" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="status"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Status</FormLabel>
                  <FormControl>
                    <select
                      {...field}
                      className="w-full border rounded p-2" // Add styling if needed
                    >
                      <option value="ToDo">To Do</option>
                      <option value="InProgress">In Progress</option>
                      <option value="Done">Done</option>
                    </select>
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="dueDate"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Due Date</FormLabel>
                  <FormControl>
                    <Input type="date" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="description"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Description</FormLabel>
                  <FormControl>
                    <Textarea
                      placeholder="Enter description"
                      {...field}
                      className="resize-none min-h-[80px]" // Optional: prevent resizing
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <div className="flex gap-2 justify-end">
              <Button type="button" variant="outline" onClick={closeTaskForm}>
                Cancel
              </Button>
              <Button type="submit">Submit</Button>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
