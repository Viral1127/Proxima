import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"

export function ProjectManagement() {
  const projects = [
    { name: "Website Redesign", manager: "John Doe", status: "In Progress", deadline: "2023-12-31" },
    { name: "Mobile App Development", manager: "Jane Smith", status: "Planning", deadline: "2024-03-15" },
    { name: "Database Migration", manager: "Mike Johnson", status: "Completed", deadline: "2023-11-30" },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Project List</CardTitle>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Project Name</TableHead>
              <TableHead>Project Manager</TableHead>
              <TableHead>Status</TableHead>
              <TableHead>Deadline</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {projects.map((project, index) => (
              <TableRow key={index}>
                <TableCell>{project.name}</TableCell>
                <TableCell>{project.manager}</TableCell>
                <TableCell>{project.status}</TableCell>
                <TableCell>{project.deadline}</TableCell>
                <TableCell>
                  <Button variant="outline" size="sm" className="mr-2">Edit</Button>
                  <Button variant="outline" size="sm">Delete</Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
        <Button className="mt-4">Add New Project</Button>
      </CardContent>
    </Card>
  )
}

