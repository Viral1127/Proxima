import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

const testimonials = [
  {
    name: "Sarah Johnson",
    role: "Project Manager",
    company: "TechCorp",
    quote: "Proxima has revolutionized how we manage projects. It's intuitive and powerful."
  },
  {
    name: "Michael Chen",
    role: "Team Lead",
    company: "InnovateCo",
    quote: "The collaboration features in Proxima have greatly improved our team's productivity."
  }
]

export function TestimonialSection() {
  return (
    <section className="py-20 bg-white">
      <div className="container mx-auto">
        <h2 className="text-3xl font-bold text-center mb-12">What Our Clients Say</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
          {testimonials.map((testimonial, index) => (
            <Card key={index}>
              <CardHeader>
                <CardTitle>{testimonial.name}</CardTitle>
                <p className="text-sm text-gray-500">{testimonial.role} at {testimonial.company}</p>
              </CardHeader>
              <CardContent>
                <p className="italic">"{testimonial.quote}"</p>
              </CardContent>
            </Card>
          ))}
        </div>
      </div>
    </section>
  )
}

