using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Onyx;
public class Assignment1
{
    private List<InvoiceGroup> _invoiceGroups = new List<InvoiceGroup>();

    public List<InvoiceGroup> InvoiceGroups
    {
        get { return _invoiceGroups; }
        set { _invoiceGroups = value; }
    }

    public Assignment1() 
    {
        TravelAgentInfo travelAgentInfo1 = new TravelAgentInfo { TravelAgent = "TravelAgent1", TotalNumberOfNights = 2};
        TravelAgentInfo travelAgentInfo2 = new TravelAgentInfo { TravelAgent = "TravelAgent2", TotalNumberOfNights = 4};

        Observation observation1 = new Observation { TravelAgent = "TravelAgent1", GuestName = "Saham", NumberOfNights = 1 };
        Observation observation2 = new Observation { TravelAgent = "TravelAgent1", GuestName = "Hoda", NumberOfNights = 3 };
        Observation observation3 = new Observation { TravelAgent = "TravelAgent2", GuestName = "Saham", NumberOfNights = 1 };
        Observation observation4 = new Observation { TravelAgent = "TravelAgent2", GuestName = "Ali", NumberOfNights = 9 };

        Invoice invoice = new Invoice { Observations = new List<Observation> { observation1, observation2, observation3, observation4 } };

        InvoiceGroup invoiceGroup = new InvoiceGroup { IssueDate = DateTime.Now, Invoices = new List<Invoice> { invoice } };

        _invoiceGroups.Add(invoiceGroup);
    }

    public List<string> QuestionA()
    {
        return _invoiceGroups
            .SelectMany(s => s.Invoices, (s, invoice) => new { s, invoice.Observations })
            .SelectMany(x => x.Observations, (x, obser) => new { x, obser.GuestName })
            .GroupBy(g=>g.GuestName).Where(z=>z.Count() == 1).Select(x=>x.Key).ToList();
    }

    public void QuestionB()
    {
     var t =   _invoiceGroups
            .SelectMany(s => s.Invoices, (s, invoice) => new { s, invoice.Observations })
            .SelectMany(x => x.Observations, (x, obser) => new { x, obser.TravelAgent, obser.NumberOfNights })
            .GroupBy(g => g.TravelAgent).Select(s => new { TravelAgent = s.Key, Count = s.Sum(c => c.NumberOfNights) });
    }
}
