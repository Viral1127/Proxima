import Image from 'next/image'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"

const features = [
  {
    title: "Task Management",
    description: "Organize and prioritize tasks with ease.",
    image: "/task-management.svg"
  },
  {
    title: "Team Collaboration",
    description: "Work together seamlessly across projects.",
    image: "/team-collaboration.svg"
  },
  {
    title: "Progress Tracking",
    description: "Monitor project progress in real-time.",
    image: "/progress-tracking.svg"
  }
]

export function FeatureSection() {
  return (
    <section className="py-20 bg-gray-50">
      <div className="container mx-auto">
        <h2 className="text-3xl font-bold text-center mb-12">Powerful Features for Efficient Project Management</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {features.map((feature, index) => (
            <Card key={index} className="bg-white">
              <CardHeader>
                <Image src={feature.image} alt={feature.title} width={64} height={64} className="mb-4" />
                <CardTitle>{feature.title}</CardTitle>
              </CardHeader>
              <CardContent>
                <CardDescription>{feature.description}</CardDescription>
              </CardContent>
            </Card>
          ))}
        </div>
      </div>
    </section>
  )
}

